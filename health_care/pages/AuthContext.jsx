import { createContext, useContext, useState, useEffect } from 'react';

import axios from 'axios';
import { useRouter } from 'next/router';

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const cookies = new Cookies();
  const router = useRouter();

  useEffect(() => {
    const storedUser = cookies.get('user');
    if (storedUser) {
      setUser(storedUser);
    }
  }, []);

  const login = (email, cookie) => {
    sessionStorage.setItem('email', email);
    const userObject = { email, cookie };
    setUser(userObject);

    // Store user information in cookies with a 10-minute expiration
    cookies.set('user', userObject, { expires: new Date(Date.now() + 10 * 60 * 1000) });
    console.log("login" + email);
  };

  const logout = () => {
    // Remove the user information from cookies on logout
    cookies.remove('user');
    doSignOut();
  };

  async function doSignOut() {
    try {
      const response = await axios.post(
        process.env.NEXT_PUBLIC_API_ENDPOINT + '/admin/signout/',
        {},
        {
          headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
          withCredentials: true,
        }
      );
      console.log(response);
      setUser(null);
      document.cookie = null;
      router.push('/loginform');
    } catch (error) {
      console.error('Error during signout: ', error);
    }
  }

  return (
    <AuthContext.Provider value={{ user, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => useContext(AuthContext);
