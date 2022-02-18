export function encodeQuery(queryObject) {
    return Object.entries(queryObject)
        .map(([key, value]) => `${encodeURIComponent(key)}=${encodeURIComponent(value)}`)
        .join('&');
}