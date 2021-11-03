# Music recommender

## Event storming session results
https://miro.com/app/board/o9J_loR-Nqs=/

## Prerequisites
Install Docker on your machine. 

## How to run?
1. Edit docker-compose.yml. Add `SpotifyClientCredentials__ClientId` and `SpotifyClientCredentials__ClientSecret` to Spotify account.
2. Run `docker-compose up -d`
4. Go to `http://localhost:3000` - app should be up and running