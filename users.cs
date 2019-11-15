 using (PrincipalContext insPrincipalContext = new PrincipalContext(ContextType.Domain, "ADName", "OU=realusers,OU=ADUserDetails,DC=ADName,DC=local", "adconnect", "password")) 
                    { 
                        using (UserPrincipal insUserPrincipal = UserPrincipal.FindByIdentity(insPrincipalContext, email)) 
                        { 
                            if (insUserPrincipal == null) 
                            { 
                                UserPrincipal UserPrincipal1 = new UserPrincipal(insPrincipalContext, userId, password, true); 
                                UserPrincipal1.UserPrincipalName = email; 
                                UserPrincipal1.SamAccountName = "<Generate random user id>";//SAMaccount - You have to write your own logic to generate this 
                                UserPrincipal1.Name = "Sekar Thangavel";//name 
                                UserPrincipal1.Surname = "Thangavel";//Lastname 
                                UserPrincipal1.GivenName = "Sekar";//firstname 
                                UserPrincipal1.DisplayName = String.Format("{0} {1}", "Sekar"), "Thangavel");//display name 
                                UserPrincipal1.EmailAddress = "sekar.thangavel@hotmail.com";//Email address 
                                UserPrincipal1.SetPassword(password); 
                                UserPrincipal1.ExpirePasswordNow(); 
                                UserPrincipal1.Save(); 
 
                           
                                DirectoryEntry oDirectoryUpdate = (UserPrincipal1.GetUnderlyingObject() as DirectoryEntry); 
 
                                if (oDirectoryUpdate != null) 
                                { 
                                    oDirectoryUpdate.Properties[strProxyAddress].Value = Convert.ToString(item[strYouProxyEmail]); 
                                    oDirectoryUpdate.Properties[strProxyAddress].Value = Convert.ToString(item[strYouProxyEmail]); 
                                    oDirectoryUpdate.CommitChanges(); 
                                    oDirectoryUpdate.Close(); 
                                } 
                            } 
                        } 
                }
