#!/usr/bin/env python
# coding: utf-8

# In[1]:


from pandas import*


# In[2]:


df = read_csv("benchmark-report.csv")


# In[3]:


df = df.drop(df.columns[[i for i in range(1,43)]], axis=1)


# In[4]:




# In[5]:


df = df.drop(df.columns[[3,4]], axis = 1)


# In[15]:


df.rename(columns = {"Mean [μs]": "Microsegundos"}, inplace=True)
df.rename(columns = {"Allocated [B]": "BytesMemoria"}, inplace=True)
df.rename(columns = {"size": "Tamaño"}, inplace=True)
df.rename(columns = {"Method": "Method"}, inplace=True)

for i in range(0, len(df["Microsegundos"])):
    df["Microsegundos"][i] = float(df["Microsegundos"][i].replace("," ,""))
   

# In[16]:


df.to_csv("benchmark-report-" + df._get_value(0, "Method")+ ".csv")

# In[ ]:




