const Router = require('express').Router;
const userRouter = new Router();
const userController = require('../controllers/user-controller');
const {body} = require('express-validator');
const authMiddleware = require('../middlewares/auth-middleware');

const userModel = require('../models/user-model');

userRouter.post('/create',
    body('email').isEmail().custom(value => {
        return userModel.findOne({email:value}).then(user => {
            if(user){
                throw new Error('E-mail already in use!');
            }
        })
    }),
    userController.create);

userRouter.post('/login', userController.login);
userRouter.post('/logout',authMiddleware, userController.logout);

userRouter.patch('/update/:id', userController.updateOne)

userRouter.get('/get', userController.getAll);
userRouter.get('/get/:id', userController.getOne);

userRouter.get('/me',authMiddleware, userController.me);

userRouter.delete('/delete', userController.deleteAll);
userRouter.delete('/delete/:id', userController.deleteOne);

module.exports = userRouter;
