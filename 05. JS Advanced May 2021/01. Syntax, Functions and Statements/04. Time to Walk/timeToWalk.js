function solve(steps, footprintLengthInMeters, speedInKilometersPerHour) {
    let totalLengthInMeters = steps * footprintLengthInMeters;
    let speedInMetersPerSecond = speedInKilometersPerHour / 3.6;
    let timeInSeconds = totalLengthInMeters / speedInMetersPerSecond + Math.trunc(totalLengthInMeters / 500) * 60;

    let seconds = Math.round(timeInSeconds % 60);
    let minutes = Math.round((timeInSeconds - seconds) / 60);
    let hours = Math.round((timeInSeconds - seconds - minutes * 60) / 3600);

    let outputSeconds = String(seconds);
    let outputMinutes = String(minutes);
    let outputHours = String(hours);
    
    if (outputSeconds.length == 1) {
        outputSeconds = "0" + outputSeconds;
    }
    if (outputMinutes.length == 1) {
        outputMinutes = "0" + outputMinutes;
    }
    if (outputHours.length == 1) {
        outputHours = "0" + outputHours;
    }

    console.log(`${outputHours}:${outputMinutes}:${outputSeconds}`);
}