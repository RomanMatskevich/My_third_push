const Router = require('express').Router;
const router = new Router();

const userRouter = require('./user-router');
const taskRouter = require('./task-router');

router.use('/user', userRouter);
router.use('/task', taskRouter);

module.exports = router;
