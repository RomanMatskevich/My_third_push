const Router = require('express').Router;
const taskRouter = new Router();
const taskController = require('../controllers/task-controller');
const authMiddleware = require('../middlewares/auth-middleware');



taskRouter.post('/create',authMiddleware, taskController.create);
taskRouter.get('/get',authMiddleware, taskController.getAll);
taskRouter.get('/get/:id',authMiddleware, taskController.getOne);

taskRouter.patch('/update/:id',authMiddleware ,taskController.updateOne)

taskRouter.delete('/delete',taskController.deleteAll);
taskRouter.delete('/delete/:id',authMiddleware,taskController.deleteOne);

module.exports = taskRouter;