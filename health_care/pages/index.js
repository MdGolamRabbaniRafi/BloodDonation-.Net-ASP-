import Image from 'next/image'
import { Inter } from 'next/font/google'
import Home1 from "../Components/Home"
import Contact from '../Components/Contact'
import About from '../Components/About'
import AdminNav from './AdminNav'
import AdminDashboard from './AdminDashboard'
import AddProfilePic from './AddProfilePic'
import Team from '@/Components/Team'



export default function Home() {
  return (
    <div>
      <Home1 />
      <AdminNav />
      <AdminDashboard />
      <AddProfilePic />
      <Contact />
      <Team />

      <About />
    </div>
  )
}
