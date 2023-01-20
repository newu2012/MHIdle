#!/usr/bin/env bash
docker build . -t registry.heroku.com/mh-idle/web:latest  # build image
docker run -p 5000:5000 -d registry.heroku.com/mh-idle/web:latest # for local testing