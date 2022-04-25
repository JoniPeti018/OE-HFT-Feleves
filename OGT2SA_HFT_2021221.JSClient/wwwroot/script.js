let log = console.log;

let studio = [];
let connection;
getData();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:9346/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("StudioCreated", (user, message) => {
        getData();
    });
    connection.on("StudioDeleted", (user, message) => {
        getData();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        log("SignalR Connected.");
    } catch (err) {
        log(err);
        setTimeout(start, 5000);
    }
};



async function getData() {
    log('getData');
    await fetch('http://localhost:9346/studio')
        .then(x => x.json())
        .then(y => {
            studios = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    studios.forEach(t => {
        document.getElementById('resultarea').innerHTML += "<tr><td>" + t.studio_id + `</td><td><input type="text" id="studioname_${t.studio_id}" value="${t.studio_name}">` + `</td><td><input type="text" id="founded_${t.studio_id}" value="${t.founded}">` + `</td><td><input type="text" id="founder_${t.studio_id}" value="${t.founder}">` + `</td><td><input type="text" id="headquarters_${t.studio_id}" value="${t.headquarters}">` + `</td><td><button type="button" onclick="remove(${t.studio_id});">Delete</button><button type="button" onclick="update(${t.studio_id});">Update</button></td></tr>`;
    });
}

function create() {
    let name = document.getElementById('studioname').value;
    fetch('http://localhost:9346/studio', {
        method: 'POST',
        headers: { 'Content-Type': "application/json" },
        body: JSON.stringify({ studio_name: name, founded: "ToBeChanged", founder: "ToBeChanged", headquarters: "ToBeChanged" }),
    })
        .then(response => response)
        .then(data => {
            log("Studio created");
            getData();
        })
        .catch((error) => { log("Error: ", error); });
}

function remove(id) {
    fetch('http://localhost:9346/studio/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': "application/json" },
        body: null,
    })
        .then(response => response)
        .then(data => {
            log("Studio deleted");
            getData();
        })
        .catch((error) => { log("Error: ", error); });
}


function update(id) {
    log("update studio " + id);
    let name = document.getElementById('studioname_' + id).value;
    let foundd = document.getElementById('founded_' + id).value;
    let foundr = document.getElementById('founder_' + id).value;
    let headq = document.getElementById('headquarters_' + id).value;
    fetch('http://localhost:9346/studio', {
        method: 'PUT',
        headers: { 'Content-Type': "application/json" },
        body: JSON.stringify({ studio_id: id, studio_name: name, founded: foundd, founder: foundr, headquarters: headq }),
    })
        .then(response => response)
        .then(data => {
            log("Studio created");
            getData();
        })
        .catch((error) => { log("Error: ", error); });
}