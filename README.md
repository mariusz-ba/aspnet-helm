# WebApplication

Simple ASP.NET Core application with automatic deployment to Kubernetes cluster.

## About

Every new commit on master branch triggers a `master-build-and-deploy` workflow. This workflow:

1. Builds new docker image with web application. The docker image has 2 tags
    - `mariuszba/webapp:{last commit short sha}`
    - `mariuszba/webapp:latest`

    Then images are pushed to Dockerhub.

2. Once images are built and pushed successfully - webapp is deployed to kubernetes cluster using helm chart.
    - At first - migration job is executed and it performs database migration.
    - When migration job completes successfully - new application is deployed using rolling update.

## Info

Right now automatic deployment will fail due to removed `KUBECONFIG_FILE` and `DOCKER_HUB_PASS` secret in repository. To make everything work just provide mentioned secrets.

- `KUBECONFIG_FILE` - base64 encoded contents of KUBECONFIG file that can be used to deploy app to `local` namespace in the cluster.
- `DOCKER_HUB_PASS` - Dockerhub token necessary for pushing images.
