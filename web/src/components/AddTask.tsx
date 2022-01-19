import React, { useState } from 'react'
import { ITask } from '../types/task'

interface AddTaskProps {
    onAdd: any
}

const AddTask = ( {onAdd }: AddTaskProps) => {

    const [text, setText] = useState<string>('');
    const [day, setDay] = useState<string>('');
    const [reminder, setReminder] = useState<boolean>(false);

    const onSubmit = (e: any) => {
        e.preventDefault();

        if(!text){
            alert('Please add a task');
            return;
        }

        const task:ITask = {
            id: 0
            , text: text
            , day: day
            , reminder: reminder
        };

        onAdd(task);

        setText('');
        setDay('');
        setReminder(false);
    }

    return (
        <form 
            className='add-form'
            onSubmit={onSubmit}>
            <div className='form-control'>
                <label>Task</label>
                <input 
                    type='text'
                    placeholder='Add Task'
                    value={text}
                    onChange={(e) => setText(e.target.value)}/>
            </div>
            <div className='form-control'>
                <label>Day & Time</label>
                <input 
                    type='text'
                    placeholder='Add Day & Time'
                    value={day}
                    onChange={(e) => setDay(e.target.value)}/>
            </div>
            <div className='form-control form-control-check'>
                <label>Reminder</label>
                <input 
                    type='checkbox' 
                    checked={reminder}
                    onChange={(e) => setReminder(e.currentTarget.checked)}/>
            </div>

            <input 
                type='submit'
                className='btn btn-block'
                value='Save Task' />
        </form>
    )
}

export default AddTask;