apiVersion: v1
kind: Service
metadata:
  name: {{ .Release.Name }}-postgres
spec:
  selector:
    app: {{ .Release.Name }}-postgres-db
  ports:
  - protocol: TCP
    port: 5432