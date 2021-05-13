apiVersion: v1
kind: Secret
metadata:
  name: {{ .Release.Name }}-postgres-secret
stringData:
  user: {{ .Values.postgres.credentials.username | quote }}
data:
  password: {{ .Values.postgres.credentials.password | quote }}
