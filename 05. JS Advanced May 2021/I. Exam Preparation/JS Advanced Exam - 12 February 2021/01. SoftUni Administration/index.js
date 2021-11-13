function solve() {
    let addButton = document.querySelector(".admin-view .action button");
    addButton.addEventListener("click", addLectureHandler);

    let modules = {};

    function addLectureHandler(e) {
        e.preventDefault();

        //Get and validate input
        let lectureNameInput = document.querySelector("input[name=\"lecture-name\"]");
        let dateInput = document.querySelector("input[name=\"lecture-date\"]");
        let moduleInput = document.querySelector("select[name=\"lecture-module\"]");

        let lectureName = lectureNameInput.value;
        let lectureDate = dateInput.value;
        let moduleName = moduleInput.value.toUpperCase();

        if (lectureName == "" || lectureDate == "" || moduleName == "Select module") {
            return;
        }

        //Internal logic of modules
        if (!modules[moduleName]) {
            modules[moduleName] = [];
        }

        let currentLecture = { lectureName: lectureName, lectureDate: lectureDate };
        modules[moduleName].push(currentLecture);

        //Logic of modules in DOM
        lectureNameInput.value = "";
        dateInput.value = "";
        moduleInput.value = "Select modules";

        createTraining(modules);
    }


    function createTraining(modules) {
        let modulesDiv = document.querySelector(".modules");
        modulesDiv.innerHTML = "";

        for (const moduleName in modules) {
            let moduleDiv = createModule(moduleName);
            let moduleUl = document.createElement("ul");

            let lectures = modules[moduleName];
            lectures
                .sort((a, b) => a.lectureDate.localeCompare(b.lectureDate))
                .forEach(l => {
                    let lectureName = l.lectureName;
                    let lectureDate = l.lectureDate;
                    let lectureLi = createLecture(lectureName, lectureDate);

                    moduleUl.appendChild(lectureLi);

                    let deleteButton = lectureLi.querySelector("button");
                    deleteButton.addEventListener("click", (e) => {
                        let lectureLi = e.currentTarget.parentElement;

                        modules[moduleName] = modules[moduleName].filter(l => !(l.lectureName == lectureName && l.lectureDate == lectureDate));

                        if (modules[moduleName].length == 0) {
                            delete modules[moduleName];

                            lectureLi.parentElement.parentElement.remove();
                        }
                        else {
                            lectureLi.remove();
                        }
                    });
                });

            moduleDiv.appendChild(moduleUl);
            modulesDiv.appendChild(moduleDiv);
        }
    }

    function createLecture(lectureName, lectureDate) {
        lectureLi = document.createElement("li");
        lectureLi.classList.add("flex");

        let lectureHeader = document.createElement("h4");
        lectureHeader.textContent = `${lectureName} - ${formatLectureDate(lectureDate)}`;

        let deleteButton = document.createElement("button");
        deleteButton.textContent = "Del";
        deleteButton.classList.add("red");

        lectureLi.appendChild(lectureHeader);
        lectureLi.appendChild(deleteButton);

        return lectureLi;
    }

    function createModule(moduleName) {
        let moduleDiv = document.createElement("div");
        moduleDiv.classList.add("module");

        moduleHeader = document.createElement("h3");
        moduleHeader.textContent = `${moduleName}-MODULE`;
        moduleDiv.appendChild(moduleHeader);

        return moduleDiv;
    }

    function formatLectureDate(lectureDate) {
        let [date, time] = lectureDate.split('T');
        return `${date.replace(/-/g, '/')} - ${time}`;
    }
}