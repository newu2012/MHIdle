## How to build and update docker container

Run this commands in this folder

1. docker build . -t registry.heroku.com/mh-idle/web:latest <-- building image
2. docker run -p 5000:5000 -d a1b2			<-- for local testing, use image id after -d
3. heroku container:login	<-- if auth doesn't work
4. heroku container:push web -a mh-idle	<-- build and push container to heroku
5. heroku container:release web -a mh-idle	<-- release built container on production
