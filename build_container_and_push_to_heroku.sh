#!/usr/bin/env bash
docker build . -t registry.heroku.com/mh-idle/web:latest  # build image
heroku container:login	# if auth doesn't work
heroku container:push web -a mh-idle  # build and push container to heroku
heroku container:release web -a mh-idle # release built container on production
