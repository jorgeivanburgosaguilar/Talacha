import { google } from "googleapis";
import { createObjectCsvWriter } from "csv-writer";
import "dotenv/config";

const API_KEY = process.env.YOUTUBE_API_KEY;
const USERNAME = process.env.YOUTUBE_USERNAME;
const NOMBREARCHIVO = "videos.csv";
const YOUTUBE_URL = "https://youtu.be/";

async function playlistItemsList(service, part, playlistId, pageToken) {
  const response = await service.playlistItems.list({
    part: part,
    playlistId: playlistId,
    pageToken: pageToken,
    maxResults: 50,
    key: API_KEY,
  });
  return response.data;
}

async function channelsListMine(service, part) {
  const response = await service.channels.list({
    part: part,
    forUsername: USERNAME,
    key: API_KEY,
  });
  return response.data;
}

async function main() {
  const service = google.youtube({ version: "v3", auth: API_KEY });

  try {
    const response = await channelsListMine(service, "contentDetails");

    const csvWriter = createObjectCsvWriter({
      path: NOMBREARCHIVO,
      header: [
        { id: "publishedAt", title: "Fecha" },
        { id: "title", title: "Titulo" },
        { id: "description", title: "Descripcion" },
        { id: "videoId", title: "Vinculo" },
      ],
      encoding: "utf16le",
    });

    const records = [];

    for (const channel of response.items) {
      const playlistId = channel.contentDetails.relatedPlaylists.uploads;

      let nextPageToken = "";
      do {
        const playlistResponse = await playlistItemsList(
          service,
          "snippet",
          playlistId,
          nextPageToken
        );

        for (const playlistItem of playlistResponse.items) {
          const publishedAt = playlistItem.snippet.publishedAt;
          const title = playlistItem.snippet.title;
          const description = playlistItem.snippet.description.replace(/\n/g, ". ");
          const videoId = YOUTUBE_URL + playlistItem.snippet.resourceId.videoId;

          records.push({ publishedAt, title, description, videoId });
        }

        nextPageToken = playlistResponse.nextPageToken;
      } while (nextPageToken);
    }

    // Write to CSV
    csvWriter
      .writeRecords(records)
      .then(() => console.log(`${records.length} videos encontrados para ${USERNAME}`));
  } catch (err) {
    console.error("Error:", err);
  }
}

main();
