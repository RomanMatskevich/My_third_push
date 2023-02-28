const mongoose = require('mongoose');

module.exports = mongoose.model('Task', new mongoose.Schema({
    description:{type: String, required:true, trim: true},

    completed :{type: Boolean, default:false, required:true},
    owner:{
        type: mongoose.Schema.Types.ObjectId,
        required: true,
        ref: 'User'
    }
}))