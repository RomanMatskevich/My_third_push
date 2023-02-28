const os = require("os");
const fs = require("fs");

console.log(`Hello, ${os.userInfo().username}!`);

fs.writeFile("task03.txt", `Hello, ${os.userInfo().username}!`, error=>{
    if(error) throw error;
});