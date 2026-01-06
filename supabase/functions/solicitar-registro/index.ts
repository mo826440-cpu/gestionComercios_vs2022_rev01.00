// Supabase Edge Function para solicitar registro
// Envía email al admin pidiendo aprobación y crea solicitud en BD

import { serve } from "https://deno.land/std@0.168.0/http/server.ts"
import { createClient } from 'https://esm.sh/@supabase/supabase-js@2'

const ADMIN_EMAIL = 'mo826440@gmail.com'
const RESEND_API_KEY = Deno.env.get('RESEND_API_KEY')
const RESEND_API_URL = 'https://api.resend.com/emails'
const SUPABASE_URL = Deno.env.get('SUPABASE_URL')!
const SUPABASE_SERVICE_ROLE_KEY = Deno.env.get('SUPABASE_SERVICE_ROLE_KEY')!

serve(async (req) => {
  try {
    if (req.method !== 'POST') {
      return new Response(
        JSON.stringify({ error: 'Method not allowed' }),
        { status: 405, headers: { 'Content-Type': 'application/json' } }
      )
    }

    const { emailSolicitante } = await req.json()

    if (!emailSolicitante) {
      return new Response(
        JSON.stringify({ error: 'emailSolicitante is required' }),
        { status: 400, headers: { 'Content-Type': 'application/json' } }
      )
    }

    // Crear cliente de Supabase con service role para acceso completo
    const supabase = createClient(SUPABASE_URL, SUPABASE_SERVICE_ROLE_KEY)

    // Verificar si ya existe una solicitud
    const { data: existente } = await supabase
      .from('solicitudes_registro')
      .select('*')
      .eq('email_solicitante', emailSolicitante.toLowerCase())
      .eq('estado', 'pendiente')
      .single()

    let solicitudId

    if (existente) {
      // Ya existe una solicitud pendiente
      solicitudId = existente.id
    } else {
      // Crear nueva solicitud
      const { data: nuevaSolicitud, error: errorSolicitud } = await supabase
        .from('solicitudes_registro')
        .insert({
          email_solicitante: emailSolicitante.toLowerCase(),
          estado: 'pendiente',
          fecha_solicitud: new Date().toISOString(),
        })
        .select()
        .single()

      if (errorSolicitud) {
        console.error('Error al crear solicitud:', errorSolicitud)
        return new Response(
          JSON.stringify({ error: 'Failed to create request', details: errorSolicitud.message }),
          { status: 500, headers: { 'Content-Type': 'application/json' } }
        )
      }

      solicitudId = nuevaSolicitud.id
    }

    // Enviar email al admin
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
            .button { display: inline-block; padding: 12px 24px; background: #667eea; color: white; text-decoration: none; border-radius: 5px; margin: 10px 5px; }
            .button-reject { background: #dc3545; }
            .info { background: white; padding: 15px; border-radius: 5px; margin: 15px 0; }
          </style>
        </head>
        <body>
          <div class="container">
            <div class="header">
              <h1>Nueva Solicitud de Registro</h1>
            </div>
            <div class="content">
              <p>Se ha recibido una nueva solicitud de registro en el sistema:</p>
              <div class="info">
                <strong>Email del solicitante:</strong> ${emailSolicitante}<br>
                <strong>Fecha de solicitud:</strong> ${new Date().toLocaleString('es-AR')}
              </div>
              <p>Para aprobar o rechazar esta solicitud, haz clic en uno de los botones siguientes:</p>
              <p>
                <a href="${SUPABASE_URL.replace('/rest/v1', '')}/functions/v1/aprobar-registro?solicitudId=${solicitudId}&accion=aprobar" class="button">✅ Aprobar</a>
                <a href="${SUPABASE_URL.replace('/rest/v1', '')}/functions/v1/aprobar-registro?solicitudId=${solicitudId}&accion=rechazar" class="button button-reject">❌ Rechazar</a>
              </p>
              <p><small>O puedes aprobar/rechazar desde el panel de administración.</small></p>
            </div>
          </div>
        </body>
        </html>
      `

      const response = await fetch(RESEND_API_URL, {
        method: 'POST',
        headers: {
          'Authorization': `Bearer ${RESEND_API_KEY}`,
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          from: 'AdminisGo <noreply@adminisgo.com.ar>',
          to: ADMIN_EMAIL,
          subject: `Nueva solicitud de registro: ${emailSolicitante}`,
          html: emailHtml,
        }),
      })

      if (!response.ok) {
        console.error('Error al enviar email:', await response.text())
      }
    }

    return new Response(
      JSON.stringify({ success: true, solicitudId }),
      { status: 200, headers: { 'Content-Type': 'application/json' } }
    )
  } catch (error) {
    console.error('Error:', error)
    return new Response(
      JSON.stringify({ error: error.message }),
      { status: 500, headers: { 'Content-Type': 'application/json' } }
    )
  }
})

