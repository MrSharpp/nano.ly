
import { BrowserRouter ,Routes ,Route } from 'react-router-dom'
import Home from './Pages/Home'
import Blogs from './Pages/Homecomponents/Blogs'
function App() {
  return (
   <BrowserRouter>
   <Routes>
    <Route path='/' element = {<Home/>} />
    <Route path="/blog/:id" element={<Blogs/>} />
   
   </Routes>
   </BrowserRouter>
    
  )
}

export default App
