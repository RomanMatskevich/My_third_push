const userModel = require('../models/user-model');
const {validationResult} = require('express-validator');
const bcrypt = require('bcrypt');

module.exports = new class UserController{
     create(req, res, next){
         const errors = validationResult(req);
         if(!errors.isEmpty()){
             return res.status(404).json({status: 'fail', message:errors.array()[0]})
         }
         const {name, email, password} = req.body;
         userModel.create({name, email, password}).then(response => {
             return res.status(200).json({
                 status: 'success',
                 data: response
             })
         }).catch (e => res.status(404).json({status: 'fail', message: e.message}));
     }
    async login(req, res, next){
        const {email, password} = req.body;
        try {
            const user = await userModel.findOneByCredentials(email, password);
            const token = await user.generateAuthToken();
            return res.status(200).json({status: 'success', user, token});
        }catch (e) {
            res.status(400).json({status: 'fail', message: e.message})
        }
    }
    async logout(req, res, next){
        try {
            req.user.tokens = req.user.tokens.filter(token => {
               return token.token !== req.token;
            });
            await req.user.save();
            return res.status(200).json({status: 'success'});
        }catch (e) {
            res.status(500).json({status: 'fail', message: e.message})
        }
    }


    getAll(req, res, next){
         userModel.find().then(response => {
             return res.status(200).json({
                 status: 'success',
                 data: response
             })
         }).catch(e => res.status(404).json({status: 'fail', message: e.message}));
     }
     getOne(req, res, next){
         const {id} = req.params;
         userModel.findById(id).then(response => {
             if(!response)
                 return res.status(404).json({status: 'fail', message:`User with this id does not exist`})
             return res.status(200).json({
                 status: 'success',
                 data: response
             });
         }).catch(e => res.status(404).json({status: 'fail', message: e.message}))
     }
     deleteOne(req, res, next){
            const {id} = req.params;
            userModel.findByIdAndDelete(id).then(response => {
                if(!response){
                    return res.status(404).json({status: 'fail', message: `User with this id does not exist`})
                }
                return res.status(200).json({status: 'success'});
            }).catch(e => res.status(404).json({status: 'fail', message: e.message}));
    }
    deleteAll(req, res, next){
        userModel.deleteMany().then(response => {
            return res.status(200).json({status: 'success'});
        }).catch(e => res.status(404).json({status: 'fail', message: e.message}));
    }



    updateOne(req, res, next){
        const {id} = req.params;
        const updates = ['name', 'email', 'password'];
        userModel.findById(id).then(user => {
            updates.forEach(update => user[update] = req.body[update])
            user.save().then(response => {
                return res.status(200).json({
                    status: 'success',
                    data: response
                })
            }).catch(e => res.status(404).json({status: 'fail', message: e.message}));
        }).catch(e => res.status(404).json({status: 'fail', message: e.message}));
    }



    async me(req, res, next){
         const userData = await userModel.findById(req.user.id).populate('tasks')
         res.status(200).json({
             status: 'success',
             user: userData,
             tasks: userData.tasks
         })
    }
};