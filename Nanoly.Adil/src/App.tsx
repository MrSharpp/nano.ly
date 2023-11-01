//import { useState } from 'react'
//import reactLogo from './assets/react.svg'
//import viteLogo from '/vite.svg'
import './App.css'
import { BrowserRouter ,Routes ,Route } from 'react-router-dom'
import Home from "./Pages/Home"
import About from "./Pages/About"
import Contactus from './Pages/Contactus'


function App() {
  //const [count, setCount] = useState(0)

  return (
   <BrowserRouter>
   <Routes>
    <Route path='/' element = {<Home/>} />
    <Route path='about' element = {<About/>} />
    <Route path='contactus' element = {<Contactus/>} />
   </Routes>
   </BrowserRouter>
  )
}

export default App
