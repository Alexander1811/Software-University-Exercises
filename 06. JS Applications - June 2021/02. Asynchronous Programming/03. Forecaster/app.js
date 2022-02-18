function attachEvents() {
    let getWeatherButton = document.querySelector("#submit");
    let locationInput = document.querySelector("#location");
    getWeatherButton.addEventListener("click", getWeatherHandler);

    let conditions = {
        "Sunny": '☀',
        "Partly sunny": '⛅',
        "Overcast": '☁',
        "Rain": '☂'
    }

    function getWeatherHandler() {
        let forecastContainer = document.querySelector("#forecast");

        let currentForecastContainer = document.querySelector("#current");
        let upcomingForecastContainer = document.querySelector("#upcoming");

        let currentForecast = currentForecastContainer.querySelector("div .forecasts");
        let upcomingForecasts = upcomingForecastContainer.querySelectorAll("div .forecast-info");
        if (currentForecast) {
            currentForecast.remove();
        }
        if (upcomingForecasts) {
            Array.from(upcomingForecasts).forEach(f => f.remove());
        }
        Array.from(currentForecastContainer.querySelectorAll("div .label")).slice(1).forEach(f => f.remove());

        fetch("http://localhost:3030/jsonstore/forecaster/locations")
            .then(body => body.json())
            .then(locationsInfo => {
                let locationName = locationInput.value;
                let location = locationsInfo.find(x => x.name == locationName);

                let currentPromise = fetch(`http://localhost:3030/jsonstore/forecaster/today/${location.code}`)
                    .then(body => body.json())
                    .then(weatherReport => {
                        let htmlReport = createWeatherElement(weatherReport);
                        currentForecastContainer.appendChild(htmlReport);
                    });

                let upcomingPromise = fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${location.code}`)
                    .then(body => body.json())
                    .then(upcomingWeatherReport => {
                        let htmlReport = createUpcomingWeatherReport(upcomingWeatherReport);
                        upcomingForecastContainer.appendChild(htmlReport);
                    });

                Promise.all([currentPromise, upcomingPromise]).then(x => {
                    forecastContainer.style.display = "block";
                });
            })
            .catch(err => {
                let errorDiv = document.createElement("div");
                errorDiv.classList.add("label");
                errorDiv.textContent = "Error";
                currentForecastContainer.appendChild(errorDiv);
            });

        function createUpcomingWeatherReport(upcomingWeatherReport) {
            let forecastInfoDiv = document.createElement("div");
            forecastInfoDiv.classList.add("forecast-info");

            let day1Html = createUpcomingDayReport(upcomingWeatherReport.forecast[0]);
            let day2Html = createUpcomingDayReport(upcomingWeatherReport.forecast[1]);
            let day3Html = createUpcomingDayReport(upcomingWeatherReport.forecast[2]);

            forecastInfoDiv.appendChild(day1Html);
            forecastInfoDiv.appendChild(day2Html);
            forecastInfoDiv.appendChild(day3Html);

            return forecastInfoDiv;
        }

        function createUpcomingDayReport(forecast) {
            let upcomingSpan = document.createElement("span");
            upcomingSpan.classList.add("upcoming");

            let symbolSpan = document.createElement("span");
            symbolSpan.classList.add("symbol");
            symbolSpan.textContent = conditions[forecast.condition];

            let temperatureSpan = document.createElement("span");
            temperatureSpan.classList.add("forecast-data");
            temperatureSpan.textContent = `${forecast.high}°/${forecast.low}°`;

            let conditionNameSpan = document.createElement("span");
            conditionNameSpan.classList.add("forecast-data");
            conditionNameSpan.textContent = forecast.condition;

            upcomingSpan.appendChild(symbolSpan);
            upcomingSpan.appendChild(temperatureSpan);
            upcomingSpan.appendChild(conditionNameSpan);

            return upcomingSpan;
        }

        function createWeatherElement(weatherReport) {
            let forecastsDiv = document.createElement("div");
            forecastsDiv.classList.add("forecasts");

            let conditionSymbolSpan = document.createElement("span");
            conditionSymbolSpan.classList.add("condition", "symbol");
            conditionSymbolSpan.textContent = conditions[weatherReport.forecast.condition];

            let conditionSpan = document.createElement("span");
            conditionSpan.classList.add("condition");

            let locationSpan = document.createElement("span");
            locationSpan.classList.add("forecast-data");
            locationSpan.textContent = weatherReport.name;

            let temperatureSpan = document.createElement("span");
            temperatureSpan.classList.add("forecast-data");
            temperatureSpan.textContent = `${weatherReport.forecast.high}°/${weatherReport.forecast.low}°`;

            let conditionNameSpan = document.createElement("span");
            conditionNameSpan.classList.add("forecast-data");
            conditionNameSpan.textContent = weatherReport.forecast.condition;

            conditionSpan.appendChild(locationSpan);
            conditionSpan.appendChild(temperatureSpan);
            conditionSpan.appendChild(conditionNameSpan);

            forecastsDiv.appendChild(conditionSymbolSpan);
            forecastsDiv.appendChild(conditionSpan);

            return forecastsDiv;
        }
    }
}

attachEvents();