const fs = require("fs");

fs.appendFile("task02.txt", "Hello world!\n", error=>{
    if(error) throw error;
});