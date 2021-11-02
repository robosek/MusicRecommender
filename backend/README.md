# Music recommender api
API designed to recommend music based on search parameters.

## Prerequisites
Install Docker on your machine

## How to run?
1. Edit appsettings.Development.json. Add clientId and clientSecret to Spotify account.
2. Build docker image. `docker build -t music-recommender-api .`
3. Run docker image. `docker run -d -p 5001:5001 -p 5000:5000 music-recommender-web`
4. Go to `http://localhost:5000/swagger/index.html` - app should be up and running