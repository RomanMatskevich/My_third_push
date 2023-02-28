const taskModel = require('../models/task-model');

module.exports = new class TaskController{
    async create(req, res, next){
        try{
            const {description} = req.body;
            const taskData = await taskModel.create({description, owner: req.user.id})
            return res.status(200).json({
                status: 'success',
                data: taskData
            });
        }catch (e){
            res.status(404).json({status: 'fail', message: e.message})
        }
    }
    async getAll(req, res, next){
        try{
            const tasks = await taskModel.find({owner: req.user.id});
            return res.status(200).json({
                status: 'success',
                data: tasks
            });
        }catch (e){
            res.status(404).json({status: 'fail', message: e.message})
        }
    }
    async getOne(req, res, next){
        try{
            const {id} = req.params;
            const taskData = await taskModel.findById(id);

            if (!taskData || taskData.owner.toString() !== req.user.id){
                return res.status(404).json({status: 'fail', message:`Access denied`});
            }
            return res.status(200).json({
                status: 'success',
                data: taskData
            });
        }catch (e){
            res.status(404).json({status: 'fail', message: e.message})
        }
    }
    async deleteOne(req, res, next){
        try{
            const {id} = req.params;
            const candidate = await taskModel.findById(id);

            if (!candidate || candidate.owner.toString() !== req.user.id ){
                return res.status(404).json({status: 'fail', message:`Access denied`});
            }
            const taskData = await candidate.delete();
            return res.status(200).json({
                status: 'success',
                data: taskData
            });
        }catch (e){
            res.status(404).json({status: 'fail', message: e.message})
        }
    }
    async deleteAll(req, res, next){
        try{
            await taskModel.deleteMany();
            return res.status(200).json({
                status: 'success',
            });
        }catch (e){
            res.status(404).json({status: 'fail', message: e.message})
        }
    }

    async updateOne(req, res, next){
        try{
            const {id} = req.params;
            const candidate = await taskModel.findById(id);

            if (!candidate || candidate.owner.toString() !== req.user.id ){
                return res.status(404).json({status: 'fail', message:`Access denied`});
            }
            const {description, completed} = req.body;
            candidate.description = description;
            candidate.completed = completed;
            const taskData = await candidate.save()
            return res.status(200).json({
                status: 'success',
                data: taskData
            });
        }catch (e){
            res.status(404).json({status: 'fail', message: e.message})
        }
    }

};