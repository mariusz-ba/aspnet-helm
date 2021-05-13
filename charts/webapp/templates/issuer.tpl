apiVersion: cert-manager.io/v1
kind: Issuer
metadata:
  name: {{ .Release.Name }}-letsencrypt-{{ .Values.issuers.env }}
spec:
  acme:
    server: https://acme-{{ if ne .Values.issuers.env "prod" }}staging-{{ end }}v02.api.letsencrypt.org/directory
    {{- if eq .Values.issuers.env "prod" }}
    email: {{ .Values.issuers.prod.email }}
    {{- else }}
    email: {{ .Values.issuers.staging.email }}
    {{- end }}
    privateKeySecretRef:
      name: {{ .Release.Name }}-letsencrypt-{{ .Values.issuers.env }}
    solvers:
    - http01:
        ingress:
          class: nginx