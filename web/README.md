# Music recommender web
Web application designed for music search. Type what you look for and receive results immediately.

## Prerequisites
Install Docker on your machine

## How to run?
1. Edit src/config.js. Put music recommender api url.
2. Build docker image. `docker build -t music-recommender-web .`
3. Run docker image. `docker run -d -p 3000:3000 music-recommender-web`
4. Go to `http://localhost:3000` - app should be up and running