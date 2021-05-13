apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: {{ .Release.Name }}-ingress
  annotations:
    kubernetes.io/ingress.class: "nginx"
    cert-manager.io/issuer: "{{ .Release.Name }}-letsencrypt-{{ .Values.issuers.env }}"
spec:
  tls:
  - hosts:
    - {{ .Values.ingress.host }}
    secretName: {{ .Release.Name }}-tls-secret
  rules:
  - host: {{ .Values.ingress.host }}
    http:
      paths:
      - path: /
        pathType: Prefix
        backend:
          service:
            name: {{ .Release.Name }}-webapp
            port:
              number: 80