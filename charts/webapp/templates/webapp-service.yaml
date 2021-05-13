apiVersion: v1
kind: Service
metadata:
  name: {{ .Release.Name }}-webapp
spec:
  selector:
    app: {{ .Release.Name }}-webapp-front
  ports:
  - protocol: TCP
    port: 80