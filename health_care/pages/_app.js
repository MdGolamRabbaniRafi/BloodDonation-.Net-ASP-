import Navbar from '@/Components/Navbar'
import { useRouter } from 'next/router';
import '@/styles/globals.css'

export default function App({ Component, pageProps }) {
  const router = useRouter();
  const isLogin = router.pathname === '/Auth/Login';
  const isSignUp = router.pathname === '/Auth/Registration';
  const isUserNav = router.pathname === '/User/UserNav';
  const isUserDashboard = router.pathname === '/User/Dashboard';
  const isUserConsultancy = router.pathname === '/User/UserConsultancy';
  const isUserSendEmail = router.pathname === '/User/UserSendEmail';
  const isUserPost = router.pathname === '/User/UserPost';

  
  return (
    <div>
      {
        !isLogin &&!isSignUp && !isUserNav && isUserDashboard && !isUserConsultancy && !isUserSendEmail && !isUserPost && 
       <Navbar />
      }
      
      <Component {...pageProps} />

    </div>
    
    
  );
  
}
