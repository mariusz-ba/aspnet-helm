apiVersion: v1
kind: Secret
metadata:
  name: {{ .Release.Name }}-webapp-secret
data:
  {{- $host := printf "Host=%s-postgres" .Release.Name }}
  {{- $database := .Values.webapp.database.name }}
  {{- $username := .Values.webapp.database.username }}
  {{- $password := .Values.webapp.database.password | b64dec }}
  connectionString: {{ printf "%s;Database=%s;Username=%s;Password=%s" $host $database $username $password | b64enc }}