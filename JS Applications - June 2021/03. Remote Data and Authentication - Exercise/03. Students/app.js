window.addEventListener("load", loadStudentsHandler);

let submitButton = document.querySelector("#submit");
submitButton.addEventListener("click", addStudentHandler);

let url = "http://localhost:3030/jsonstore/collections/students";

async function loadStudentsHandler() {
    let tbody = document.querySelector("#results tbody");
    Array.from(tbody.children).forEach(li => li.remove());

    let studentsRequest = await fetch(url);
    let students = await studentsRequest.json();
    
    Object.values(students).forEach(student => {
        let studentTr = createStudentTr(student);
        
        tbody.appendChild(studentTr);
    });
}

async function addStudentHandler(e) {
    e.preventDefault();

    let formData = new FormData(e.target.parentElement);
    let newStudent = {
        firstName: formData.get("firstName"),
        lastName: formData.get("lastName"),
        facultyNumber: formData.get("facultyNumber"),
        grade: formData.get("grade")
    }

    if (!validateInput(newStudent.firstName, newStudent.lastName, newStudent.facultyNumber, newStudent.grade)) {
        return;
    }

    let createResponse = await fetch(url, {
        headers: { "Content-Type": "application/json" },
        method: "Post",
        body: JSON.stringify(newStudent)
    });

    if (!createResponse.ok) {
        return alert("Cannot add student!");
    }

    loadStudentsHandler();
}

function createStudentTr(student) {
    let studentTr = document.createElement("tr");

    let firstNameTd = document.createElement("td");
    firstNameTd.textContent = student.firstName;

    let lastNameTd = document.createElement("td");
    lastNameTd.textContent = student.lastName;

    let facultyNumberTd = document.createElement("td");
    facultyNumberTd.textContent = student.facultyNumber;

    let gradeTd = document.createElement("td");
    gradeTd.textContent = student.grade;

    studentTr.appendChild(firstNameTd);
    studentTr.appendChild(lastNameTd);
    studentTr.appendChild(facultyNumberTd);
    studentTr.appendChild(gradeTd);

    return studentTr;
}

function validateInput(firstName, lastName, facultyNumber, grade) {
    let hasEmptyFields = firstName.trim() == "" ||
        lastName.trim() == "" ||
        facultyNumber.trim() == "" ||
        grade.trim() == "";

    let hasNaNInputs = facultyNumber.split().some(d => isNaN(d)) || isNaN(grade);

    if (hasEmptyFields) {
        alert("All fields are required!");
        return false;
    }
    if (hasNaNInputs) {
        alert("Faculty number and Grade must be numbers!");
        return false;
    }

    return true;
}
