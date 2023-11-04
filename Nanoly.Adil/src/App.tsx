
import { BrowserRouter ,Routes ,Route } from 'react-router-dom'
import Home from './Pages/Home'
import About from "./Pages/About"
import Contactus from './Pages/Contactus'
import AdilBlogs from './Pages/Homecomponents/AdilBlogs'
import Amirblogs from './Pages/Homecomponents/AmirBlogs'
import Ahmadblogs from './Pages/Homecomponents/AhmadBlogs'
import Shamsblogs from './Pages/Homecomponents/ShamsBlogs'



function App() {


  return (
   
    
   <BrowserRouter>
   <Routes>
    <Route path='/' element = {<Home/>} />
    <Route path="/adilblogs" element={<AdilBlogs/>} />
        <Route path="/amirblogs" element={<Amirblogs/>} />
        <Route path="/shamsblogs" element={<Shamsblogs/>} />
        <Route path="/ahmadblogs" element={<Ahmadblogs/>} />

    <Route path='about' element = {<About/>} />
    <Route path='contactus' element = {<Contactus/>} />
   </Routes>
   </BrowserRouter>
    
  )
}

export default App
