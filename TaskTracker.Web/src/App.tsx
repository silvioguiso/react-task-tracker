import React, { useState, useEffect } from 'react'
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import Header from './components/Header'
import Tasks from './components/Tasks'
import AddTask from './components/AddTask'
import Footer from './components/Footer'
import About from './components/About'
import { ITask } from './types/task'

function App() {

  const [showAddTask, setShowAddTask] = useState<boolean>(false);
  const [tasks, setTasks] = useState<ITask[]>([]);
  const baseUrl = 'https://localhost:44325/api/task';

  useEffect(() => {
    const getTasks = async () => {
      const data = await fetchTasks();
      setTasks(data);
    }

    getTasks();
  }, []);

  const fetchTasks = async () => {
    const response = await fetch(`${baseUrl}`);
    const data = await response.json();
    return data;
  }

  const fetchTask = async (id: number) => {
    const response = await fetch(`${baseUrl}/${id}`);
    const data = await response.json();
    return data;
  }

  const addTask = async (task: ITask) => {
    
    const response = await fetch(`${baseUrl}/add`, {
      method: 'POST'
      , headers: {
        'Content-type': 'application/json'
      },
      body: JSON.stringify(task)
    });

    const newTask:ITask = await response.json();

    setTasks([...tasks, newTask]);
  }

  const deleteTask = async (id: number) => {
    
    await fetch(`${baseUrl}/${id}/delete`, {
      method: 'DELETE'
    });

    setTasks(tasks.filter((x) => x.id !== id));
  }

  const toggleReminder = async (id: number) => {
    const taskToToggle:ITask = await fetchTask(id);
    const updatedTask:ITask = { ...taskToToggle, reminder: !taskToToggle.reminder};

    const response = await fetch(`${baseUrl}/toggle`,{
      method: 'PUT'
      , headers: {
        'Content-type': 'application/json'
      }
      , body: JSON.stringify(updatedTask)
    });

    const data:ITask = await response.json();

    setTasks(tasks.map((task) => task.id === id ?
       { ...task, reminder: data.reminder }
    : task));
  }

  return (
    <Router>
      <div className="container">
        <Header 
          onAdd={() => setShowAddTask(!showAddTask)} 
          showAddTask={showAddTask} />
        <Routes>
          <Route 
            path='/' 
            element={
              <>
                { showAddTask && <AddTask onAdd={addTask}/> }
                {
                  tasks.length > 0 ? 
                    <Tasks 
                      tasks={tasks} 
                      onDelete={deleteTask}
                      onToggle={toggleReminder}/> : 'No Tasks To Show'}
                </>
              }/>
          <Route path='/about' element={<About />}/>
        </Routes>
        <Footer />
      </div>
    </Router>
  );
}

export default App;