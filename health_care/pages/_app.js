import Navbar from '../Components/Navbar';
import { useRouter } from 'next/router';
import '@/styles/globals.css'
import { AuthProvider } from './AuthContext';

export default function App({ Component, pageProps }) {
  const router = useRouter();
  const isLogin = router.pathname === '/Auth/Login';
  const isSignUp = router.pathname === '/Auth/Registration';
  const isUserNav = router.pathname === '/User/UserNav';
  const isDashboard = router.pathname === '/User/UserDashboard';
  const isUserConsultancy = router.pathname === '/User/UserConsultancy';
  const isUserSendEmail = router.pathname === '/User/UserSendEmail';
  const isUserPost = router.pathname === '/User/UserPost';
  const isAddPost= router.pathname === '/User/AddPost';
  const isEditPost= router.pathname === '/User/EditPost';


  return (
    <div>
      {
        !isLogin && !isSignUp && !isUserNav &&  !isUserConsultancy && !isUserSendEmail && !isUserPost && !isDashboard && !isAddPost && !isEditPost && 
        <Navbar />
      }
      <AuthProvider>
      <Component {...pageProps} />
      </AuthProvider>



      
    </div>
  );
}
