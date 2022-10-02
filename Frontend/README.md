# kinder-frontend
![Action status](https://github.com/Michelle-Hung/Kinder-Frontend/actions/workflows/node.js.yml/badge.svg?event=push)
[![DeepSource](https://deepsource.io/gh/Michelle-Hung/Kinder-Frontend.svg/?label=active+issues&show_trend=true&token=Wd27NtjewFLYB0F82RmCVgAv)](https://deepsource.io/gh/Michelle-Hung/Kinder-Frontend/?ref=repository-badge)
[![DeepSource](https://deepsource.io/gh/Michelle-Hung/Kinder-Frontend.svg/?label=resolved+issues&show_trend=true&token=Wd27NtjewFLYB0F82RmCVgAv)](https://deepsource.io/gh/Michelle-Hung/Kinder-Frontend/?ref=repository-badge)

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=Michelle-Hung_Kinder-Frontend&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=Michelle-Hung_Kinder-Frontend)

A practiced frontend project with vue3

Usint typescript, vuex
![image](https://user-images.githubusercontent.com/48158642/147388020-252aacdd-007a-4ea3-89a0-032f88440f26.png)

## Project setup
```
yarn install
```

### Compiles and hot-reloads for development
```
yarn serve
```

### Compiles and minifies for production
```
yarn build
```

### Lints and fixes files
```
yarn lint
```

### Dockerize vue.js app with http-server

Reference: https://v2.vuejs.org/v2/cookbook/dockerize-vuejs-app.html
```
docker build -t kinder-frontend .
```
```
docker run -it -p 8080:8080 --rm --name kinder-frontend kinder-frontend
```
