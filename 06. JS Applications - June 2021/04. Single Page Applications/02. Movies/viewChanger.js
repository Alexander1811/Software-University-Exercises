let mainSection = undefined;
let sectionViewSelector = undefined;

function initialize(mainDomElement, viewSelector) {
    mainSection = mainDomElement;
    sectionViewSelector = viewSelector;
}

async function changeView(viewPromise) {
    let view = await viewPromise;

    if (view != undefined) {
        mainSection.querySelectorAll(sectionViewSelector).forEach(v => v.remove());
        mainSection.appendChild(view);
    }
}

let viewChanger = {
    initialize,
    changeView
}

export default viewChanger;
