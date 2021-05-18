{{- define "webapp.name" -}}
{{ printf "%s-%s" .Release.Name "webapp" }}
{{- end }}

{{- define "webapp.labels" -}}
app: {{ include "webapp.name" . }}
{{- end }}

{{- define "webapp.migrator" -}}
{{ printf "%s-%s-%d" (include "webapp.name" .) "migrator" .Release.Revision }}
{{- end }}

{{- define "webapp.migrator.labels" -}}
app: {{ include "webapp.name" . }}-migrator
{{- end }}