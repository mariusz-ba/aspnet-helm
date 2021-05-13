apiVersion: apps/v1
kind: Deployment
metadata:
  name: {{ .Release.Name }}-postgres
  labels:
    app: {{ .Release.Name }}-postgres-db
spec:
  replicas: 1
  selector:
    matchLabels:
      app: {{ .Release.Name }}-postgres-db
  template:
    metadata:
      labels:
        app: {{ .Release.Name }}-postgres-db
    spec:
      containers:
      - name: postgres
        image: {{ .Values.postgres.image.repository }}:{{ .Values.postgres.image.tag }}
        ports:
        - containerPort: 5432
        env:
        - name: POSTGRES_USER
          valueFrom:
            secretKeyRef:
              name: {{ .Release.Name }}-postgres-secret
              key: user
        - name: POSTGRES_PASSWORD
          valueFrom:
            secretKeyRef:
              name: {{ .Release.Name }}-postgres-secret
              key: password
        volumeMounts:
        - name: {{ .Release.Name }}-postgres-storage
          mountPath: /var/lib/postgresql/data
      volumes:
      - name: {{ .Release.Name }}-postgres-storage
        hostPath:
          path: {{ .Values.postgres.volume.hostPath }}
      nodeSelector:
      {{- range $key, $val := .Values.postgres.nodeSelector }}
        {{ $key }}: {{ $val }}
      {{- end}}
