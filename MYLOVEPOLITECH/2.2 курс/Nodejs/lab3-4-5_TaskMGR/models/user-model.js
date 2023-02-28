const mongoose = require('mongoose');
const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');

const UserSchema = new mongoose.Schema({
    name:{type: String, required:true, trim: true},
    email:{type: String, required:[true, 'Enter your email.'], trim: true, unique: true,
        lowercase: true
    },
    password:{
        type: String,
        required:[true, 'Enter your password.'],
        trim: true,
        minlength: 7,
        validate(value){
            if(value === 'password'){
                throw new Error('Password is too simple!')
            }
        }
    },
    tokens:[{
            token:{
                type:String
            }
        }
    ]
});
UserSchema.pre('save', async function (next) {
    const user = this;
    if(user.isModified('password')){
        user.password = await bcrypt.hash(user.password, 7)
    }
    next();
});

UserSchema.methods.generateAuthToken = async function () {
    const user = this;
    const token = jwt.sign({_id: user._id.toString()}, 'some_key');
    user.tokens = user.tokens.concat({token});
    await user.save();
    return token;
};

UserSchema.statics.findOneByCredentials = async function (email, password){
    const user = await this.findOne({email})
    if(!user)
        throw new Error('Incorrect email!');
    const isMatch = await bcrypt.compare(password, user.password)
    if(!isMatch)
        throw new Error('Incorrect password!');
    return user;
};




UserSchema.virtual('tasks',{
    ref:'Task',
    localField: '_id',
    foreignField:'owner'
});

module.exports = mongoose.model('User', UserSchema);

