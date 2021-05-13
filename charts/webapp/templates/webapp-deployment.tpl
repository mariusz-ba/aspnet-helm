apiVersion: apps/v1
kind: Deployment
metadata:
  name: {{ .Release.Name }}-webapp
  labels:
    app: {{ .Release.Name }}-webapp-front
spec:
  replicas: {{ .Values.webapp.replicas }}
  selector:
    matchLabels:
      app: {{ .Release.Name }}-webapp-front
  template:
    metadata:
      labels:
        app: {{ .Release.Name }}-webapp-front
    spec:
      containers:
      - name: webapp
        image: {{ .Values.webapp.image.repository }}:{{ .Values.webapp.image.tag }}
        imagePullPolicy: {{ .Values.webapp.image.pullPolicy }}
        env:
        - name: ConnectionStrings__Database
          valueFrom:
            secretKeyRef:
              name: {{ .Release.Name }}-webapp-secret
              key: connectionString
        ports:
        - containerPort: 80
        command: [ "sh", "-c", "dotnet WebApplication.Migrator.dll && dotnet WebApplication.dll" ]
