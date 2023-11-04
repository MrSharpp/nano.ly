
import  { useState } from 'react';
import { useNavigate } from 'react-router-dom';

function Home() {
  const [showAdilBlogs, setShowAdilBlogs] = useState(false)
  const [showAmirBlogs, setShowAmirBlogs] = useState(false);
  const [showShamsBlogs, setShowShamsBlogs] = useState(false);
  const [showAhmadBlogs, setShowAhmadBlogs] = useState(false);

  const toggleAdilBlogs = () => {
    setShowAdilBlogs(!showAdilBlogs);
    setShowAmirBlogs(false);
    setShowShamsBlogs(false);
    setShowAhmadBlogs(false);
  };

  const toggleAmirBlogs = () => {
    setShowAdilBlogs(false);
    setShowAmirBlogs(!showAmirBlogs);
    setShowShamsBlogs(false);
    setShowAhmadBlogs(false);
  };

  const toggleShamsBlogs = () => {
    setShowAdilBlogs(false);
    setShowAmirBlogs(false);
    setShowShamsBlogs(!showShamsBlogs);
    setShowAhmadBlogs(false);
  };

  const toggleAhmadBlogs = () => {
    setShowAdilBlogs(false);
    setShowAmirBlogs(false);
    setShowShamsBlogs(false);
    setShowAhmadBlogs(!showAhmadBlogs);
  };

  const navigate = useNavigate();
  const Adilredirect = () => {
    navigate('/adilblogs');
  };
  const Amiredirect = () => {
    navigate('/amirblogs'); 
  };
  const Shamsredirect = () => {
    navigate('/shamsblogs'); 
  };
  const Ahmandredirect = () => {
    navigate('/ahmadblogs'); 
  };
  return (
    <div className="home"
    style={{display:"flex",gap:"40px",marginTop:"40px",justifyContent:"center",fontSize:"30px",backgroundColor:"lightblue"}}>
      
      <div className="blog-list">
        <span className="blog-item" onClick={toggleAdilBlogs} style={{cursor:"grab"}}>Adil Blogs</span>
        {showAdilBlogs && <div className="blog-content" onClick={Adilredirect} style={{marginTop:"5px",textAlign:"center",fontSize:"20px",cursor:"grab"}}>See Blogs</div>}
      </div>
      <div className="blog-list">
        <span className="blog-item" onClick={toggleAmirBlogs}style={{cursor:"grab"}}>Amir Blogs</span>
        {showAmirBlogs && <div className="blog-content" onClick={Amiredirect}  style={{marginTop:"5px",textAlign:"center",fontSize:"20px",cursor:"grab"}}>See Blogs</div>}
      </div>
      <div className="blog-list">
        <span className="blog-item" onClick={toggleShamsBlogs}style={{cursor:"grab"}}>Shams Blogs</span>
        {showShamsBlogs && <div className="blog-content" onClick={Shamsredirect}   style={{marginTop:"5px",textAlign:"center",fontSize:"20px",cursor:"grab"}}>See Blogs</div>}
      </div>
      <div className="blog-list">
        <span className="blog-item" onClick={toggleAhmadBlogs}style={{cursor:"grab"}}>Ahmad Blogs</span>
        {showAhmadBlogs && <div className="blog-content" onClick={Ahmandredirect}   style={{marginTop:"5px",textAlign:"center",fontSize:"20px",cursor:"grab"}}>See Blogs</div>}
      </div>
    </div>
  );
}

export default Home;
