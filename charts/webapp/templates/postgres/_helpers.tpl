{{- define "webapp.postgres" -}}
{{ printf "%s-%s" .Release.Name "postgres" }}
{{- end }}

{{- define "webapp.postgress.labels" -}}
app: {{ include "webapp.postgres" . }}
{{- end }}