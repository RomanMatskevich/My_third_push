const jwt = require('jsonwebtoken');
const userModel = require('../models/user-model');

module.exports  = (req, res, next) =>{
    try {
        const authHeader = req.headers.authorization;
        if(!authHeader){
             new Error();
        }
        const token = authHeader.split(' ')[1];
        if(!token){
             new Error();
        }
        const userData = jwt.verify(token, 'some_key');
        if (!userData){
            new Error();
        }
        userModel.findById({_id:userData._id}).then(user=>{
            req.user = user;
            req.token = token;
            next();
        }).catch(e => next(e))
    }catch (e) {
        return res.status(401).json({status: 'fail', message:'Please auth!!'});
    }
}