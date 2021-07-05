// HTTP requests in Postman:

// POST /api/data/musicCollection HTTP/1.1
// Host: dutifulmouth.backendless.app
// Content-Type: application/json
// Content-Length: 60
// {
//     "Singer": "Eminem",
//     "Title": "Cinderella Man"
// }

// POST /api/data/musicCollection HTTP/1.1
// Host: dutifulmouth.backendless.app
// Content-Type: application/json
// Content-Length: 56
// {
//     "Singer": "Alan Walker",
//     "Title": "Faded"
// }

// POST /api/data/musicCollection HTTP/1.1
// Host: dutifulmouth.backendless.app
// Content-Type: application/json
// Content-Length: 61
// {
//     "Singer": "Dove Cameron",
//     "Title": "We Belong"
// }

// GET /api/data/musicCollection HTTP/1.1
// Host: dutifulmouth.backendless.app

// Response body:
// [
//     {
//         "Singer": "Alan Walker",
//         "created": 1625448863920,
//         "___class": "musicCollection",
//         "Title": "Faded",
//         "ownerId": null,
//         "updated": null,
//         "objectId": "32857810-ADAC-4F3E-818E-9520F4E3AD00"
//     },
//     {
//         "Singer": "Eminem",
//         "created": 1625448790328,
//         "___class": "musicCollection",
//         "Title": "Cinderella Man",
//         "ownerId": null,
//         "updated": null,
//         "objectId": "4F388A27-4E1A-45ED-AE02-F1CFA86496D9"
//     },
//     {
//         "Singer": "Dove Cameron",
//         "created": 1625448898141,
//         "___class": "musicCollection",
//         "Title": "We Belong",
//         "ownerId": null,
//         "updated": null,
//         "objectId": "AFB8FD01-086B-4573-AFCC-24E25DFE3E0C"
//     }
// ]