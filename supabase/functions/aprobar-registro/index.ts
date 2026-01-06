// Supabase Edge Function para aprobar/rechazar solicitudes de registro
// Puede ser llamado desde email (GET) o desde panel admin (POST)

import { serve } from "https://deno.land/std@0.168.0/http/server.ts"
import { createClient } from 'https://esm.sh/@supabase/supabase-js@2'

const RESEND_API_KEY = Deno.env.get('RESEND_API_KEY')
const RESEND_API_URL = 'https://api.resend.com/emails'
const SUPABASE_URL = Deno.env.get('SUPABASE_URL')!
const SUPABASE_SERVICE_ROLE_KEY = Deno.env.get('SUPABASE_SERVICE_ROLE_KEY')!

serve(async (req) => {
  try {
    const supabase = createClient(SUPABASE_URL, SUPABASE_SERVICE_ROLE_KEY)

    // Obtener parámetros (puede ser GET desde email o POST desde panel)
    let solicitudId: string
    let accion: string

    if (req.method === 'GET') {
      const url = new URL(req.url)
      solicitudId = url.searchParams.get('solicitudId') || ''
      accion = url.searchParams.get('accion') || ''
    } else {
      const body = await req.json()
      solicitudId = body.solicitudId
      accion = body.accion
    }

    if (!solicitudId || !accion) {
      return new Response(
        JSON.stringify({ error: 'solicitudId and accion are required' }),
        { status: 400, headers: { 'Content-Type': 'application/json' } }
      )
    }

    // Obtener solicitud
    const { data: solicitud, error: errorSolicitud } = await supabase
      .from('solicitudes_registro')
      .select('*')
      .eq('id', solicitudId)
      .single()

    if (errorSolicitud || !solicitud) {
      return new Response(
        JSON.stringify({ error: 'Solicitud no encontrada' }),
        { status: 404, headers: { 'Content-Type': 'application/json' } }
      )
    }

    if (accion === 'aprobar') {
      // Generar código de verificación (6 dígitos)
      const codigo = Math.floor(100000 + Math.random() * 900000).toString()

      // Actualizar solicitud
      const fechaExpiracion = new Date()
      fechaExpiracion.setHours(fechaExpiracion.getHours() + 24) // Expira en 24 horas

      const { error: errorUpdate } = await supabase
        .from('solicitudes_registro')
        .update({
          estado: 'aprobada',
          codigo_verificacion: codigo,
          fecha_aprobacion: new Date().toISOString(),
          fecha_expiracion: fechaExpiracion.toISOString(),
          aprobado_por: 'mo826440@gmail.com',
        })
        .eq('id', solicitudId)

      if (errorUpdate) {
        return new Response(
          JSON.stringify({ error: 'Error al aprobar solicitud', details: errorUpdate.message }),
          { status: 500, headers: { 'Content-Type': 'application/json' } }
        )
      }

      // Enviar email al solicitante con el código
      if (RESEND_API_KEY) {
        const emailHtml = `
          <!DOCTYPE html>
          <html>
          <head>
            <style>
              body { font-family: Arial, sans-serif; line-height: 1.6; color: #333; }
              .container { max-width: 600px; margin: 0 auto; padding: 20px; }
              .header { background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); color: white; padding: 20px; text-align: center; border-radius: 8px 8px 0 0; }
              .content { background: #f9f9f9; padding: 20px; border-radius: 0 0 8px 8px; }
              .code { background: white; padding: 20px; text-align: center; font-size: 32px; font-weight: bold; color: #667eea; border: 2px dashed #667eea; border-radius: 5px; margin: 20px 0; }
              .warning { background: #fff3cd; padding: 15px; border-radius: 5px; margin: 15px 0; border-left: 4px solid #ffc107; }
            </style>
          </head>
          <body>
            <div class="container">
              <div class="header">
                <h1>✅ Solicitud Aprobada</h1>
              </div>
              <div class="content">
                <p>Tu solicitud de registro ha sido aprobada.</p>
                <p>Para continuar con el registro, ingresa el siguiente código de verificación:</p>
                <div class="code">${codigo}</div>
                <div class="warning">
                  <strong>⚠️ Importante:</strong>
                  <ul>
                    <li>Este código expira en 24 horas</li>
                    <li>Tienes 5 intentos para ingresarlo correctamente</li>
                    <li>No compartas este código con nadie</li>
                  </ul>
                </div>
                <p>Ve a la página de registro e ingresa este código cuando se te solicite.</p>
              </div>
            </div>
          </body>
          </html>
        `

        await fetch(RESEND_API_URL, {
          method: 'POST',
          headers: {
            'Authorization': `Bearer ${RESEND_API_KEY}`,
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            from: 'AdminisGo <noreply@adminisgo.com.ar>',
            to: solicitud.email_solicitante,
            subject: 'Tu solicitud de registro ha sido aprobada - Código de verificación',
            html: emailHtml,
          }),
        })
      }

      return new Response(
        JSON.stringify({ success: true, message: 'Solicitud aprobada y código enviado' }),
        { status: 200, headers: { 'Content-Type': 'application/json' } }
      )
    } else if (accion === 'rechazar') {
      // Rechazar solicitud
      const { error: errorUpdate } = await supabase
        .from('solicitudes_registro')
        .update({
          estado: 'rechazada',
          aprobado_por: 'mo826440@gmail.com',
        })
        .eq('id', solicitudId)

      if (errorUpdate) {
        return new Response(
          JSON.stringify({ error: 'Error al rechazar solicitud', details: errorUpdate.message }),
          { status: 500, headers: { 'Content-Type': 'application/json' } }
        )
      }

      // Enviar email al solicitante informando el rechazo
      if (RESEND_API_KEY) {
        const emailHtml = `
          <!DOCTYPE html>
          <html>
          <head>
            <style>
              body { font-family: Arial, sans-serif; line-height: 1.6; color: #333; }
              .container { max-width: 600px; margin: 0 auto; padding: 20px; }
              .header { background: #dc3545; color: white; padding: 20px; text-align: center; border-radius: 8px 8px 0 0; }
              .content { background: #f9f9f9; padding: 20px; border-radius: 0 0 8px 8px; }
            </style>
          </head>
          <body>
            <div class="container">
              <div class="header">
                <h1>❌ Solicitud Rechazada</h1>
              </div>
              <div class="content">
                <p>Lamentamos informarte que tu solicitud de registro ha sido rechazada.</p>
                <p>Si crees que esto es un error, por favor contacta al administrador en: <a href="mailto:mo826440@gmail.com">mo826440@gmail.com</a></p>
              </div>
            </div>
          </body>
          </html>
        `

        await fetch(RESEND_API_URL, {
          method: 'POST',
          headers: {
            'Authorization': `Bearer ${RESEND_API_KEY}`,
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            from: 'AdminisGo <noreply@adminisgo.com.ar>',
            to: solicitud.email_solicitante,
            subject: 'Tu solicitud de registro ha sido rechazada',
            html: emailHtml,
          }),
        })
      }

      return new Response(
        JSON.stringify({ success: true, message: 'Solicitud rechazada' }),
        { status: 200, headers: { 'Content-Type': 'application/json' } }
      )
    } else {
      return new Response(
        JSON.stringify({ error: 'Acción inválida. Debe ser "aprobar" o "rechazar"' }),
        { status: 400, headers: { 'Content-Type': 'application/json' } }
      )
    }
  } catch (error) {
    console.error('Error:', error)
    return new Response(
      JSON.stringify({ error: error.message }),
      { status: 500, headers: { 'Content-Type': 'application/json' } }
    )
  }
})

