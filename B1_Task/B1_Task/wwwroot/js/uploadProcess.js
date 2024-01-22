
let connection = new signalR.HubConnectionBuilder().withUrl("/ProcessHub").build();

connection.on("UploadProcess", (importedCount, remainingCount) => {
    let importedCountProcess = document.getElementById("uploadCount");
    let remainingCountProcess = document.getElementById("remainingCount");
    importedCountProcess.innerText = importedCount.toString();
    remainingCountProcess.innerText = remainingCount.toString();
});

function uploadProcessOnClient(importedCount, remainingCount) {
    connection.send("UploadProcess", importedCount, remainingCount);
}

function fulfilled() {
    console.log("Connection to User Hub Successful")
    let importedCountValue = 0;
    let remainingCountValue = 0;
    uploadProcessOnClient(importedCountValue, remainingCountValue);
}
function rejected() { 
    console.log("Connection to User Hub Faild")
}
connection.start().then(fulfilled, rejected)
