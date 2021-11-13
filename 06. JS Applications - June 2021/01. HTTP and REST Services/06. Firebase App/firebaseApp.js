// HTTP requests in Postman:

// POST /books/nonFiction.json HTTP/1.1
// Host: fir-app-c6579-default-rtdb.europe-west1.firebasedatabase.app
// Content-Type: application/json
// Content-Length: 111
// {
//     "author": "Jennie Allen",
//     "title": "Get Out of Your Head: Stopping the Spiral of Toxic Thoughts"
// }

// POST /books/nonFiction.json HTTP/1.1
// Host: fir-app-c6579-default-rtdb.europe-west1.firebasedatabase.app
// Content-Type: application/json
// Content-Length: 82
// {
//     "author": "Pete Buttigieg",
//     "title": "Trust: America’s Best Chance"
// }

// POST /books/nonFiction.json HTTP/1.1
// Host: fir-app-c6579-default-rtdb.europe-west1.firebasedatabase.app
// Content-Type: application/json
// Content-Length: 77
// {
//     "author": "Paul Kalanithi",
//     "title": "When Breath Becomes Air"
// }

// POST /books/romance.json HTTP/1.1
// Host: fir-app-c6579-default-rtdb.europe-west1.firebasedatabase.app
// Content-Type: application/json
// Content-Length: 69
// {
//     "author": "Colleen Hoover",
//     "title": "It Ends With Us"
// }

// POST /books/romance.json HTTP/1.1
// Host: fir-app-c6579-default-rtdb.europe-west1.firebasedatabase.app
// Content-Type: application/json
// Content-Length: 68
// {
//     "author": "Jasmine Guillory",
//     "title": "The Proposal"
// }

// POST /books/thrillers.json HTTP/1.1
// Host: fir-app-c6579-default-rtdb.europe-west1.firebasedatabase.app
// Content-Type: application/json
// Content-Length: 62
// {
//     "author": "Gillian Flynn",
//     "title": "Gone Girl"
// }

// GET /books.json HTTP/1.1
// Host: fir-app-c6579-default-rtdb.europe-west1.firebasedatabase.app

// Response body:
// {
//     "nonFiction": {
//         "-MdoAf0JL6D9vd7eClD6": {
//             "author": "Jennie Allen",
//             "title": "Get Out of Your Head: Stopping the Spiral of Toxic Thoughts"
//         },
//         "-MdoAtCqypZNvmgr4nGx": {
//             "author": "Pete Buttigieg",
//             "title": "Trust: America’s Best Chance"
//         },
//         "-MdoB2qLX58D30751JMn": {
//             "author": "Paul Kalanithi",
//             "title": "When Breath Becomes Air"
//         }
//     },
//     "romance": {
//         "-MdoBE62B6sPUbaB3C8P": {
//             "author": "Colleen Hoover",
//             "title": "It Ends With Us"
//         },
//         "-MdoBN-ubiHxRqaQlogI": {
//             "author": "Jasmine Guillory",
//             "title": "The Proposal"
//         }
//     },
//     "thrillers": {
//         "-MdoBXDpA3SjEhEs8f0B": {
//             "author": "Gillian Flynn",
//             "title": "Gone Girl"
//         }
//     }
// }