const { parse, command } = require('yargs');
const { add, list, remove, read } = require('./user');

command({
    command: 'add',
    describe: 'Add new programming language to the list',

    builder: {
        title: {
            type: 'string',
            demandOption: true,
            describe: 'Name programming language'
        },
        level: {
            type: 'string',
            demandOption: true,
            describe: 'Level for programming language'
        }
    },

    handler( {title, level} ) {
        add(title, level);
    }
});

command( {
    command: 'list',
    describe: 'Show the list of all programming languages',

    handler() {
        list();
    }
});

command( {
    command: 'remove',
    description: 'Remove one programming language',

    builder: {
        title: {
            type: 'string',
            demandOption: true,
            describe: 'Name programming language'
        }
    },

    handler( {title} ) {
        remove(title);
    }
});

command( {
    command: 'read',
    description: 'Read one programming language',

    builder: {
        title: {
            type: 'string',
            demandOption: true,
        }
    },

    handler( {title} ) {
        read(title);
    }
});


parse();