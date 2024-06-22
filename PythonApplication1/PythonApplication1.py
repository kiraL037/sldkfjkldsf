import numpy as np
import matplotlib.pyplot as plt
import pandas as pd

data = pd.read_csv(r'C:\Users\Анастас\Downloads\archive\Video Games Dataset.csv')
df=pd.DataFrame(data, columns=['Rank', 'Name', 'Platform','Year','Genre','Publisher',
                               'NorthAmerica_Sales','EurpeanUnion_Sales','Japan_Sales',
                               'Other_Sales','Global_Sales'])
X = df.drop(columns=['Name', 'Platform','Genre','Publisher','Global_Sales',
                     'NorthAmerica_Sales','EurpeanUnion_Sales','Japan_Sales',
                     'Other_Sales'])
df = df.dropna()
ys = df.groupby(['Year']).sum().reset_index()
print(df)

plt.figure(figsize=(100,100))
plt.plot(ys['Year'], ys['Global_Sales'])
plt.xlabel('Year')
plt.xlabel('Sales')
plt.title("Customer Sales for Year")

plt.show()
y=df['Global_Sales']
y.info()
X = X.reshape(X.shape[::2])
from sklearn.model_selection import train_test_split
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size= 0.30) 
from sklearn.ensemble import RandomForestRegressor   
cf= RandomForestRegressor (n_estimators= 50,  max_depth=25) 
cf.fit(X_train, y_train)

y_pred= cf.predict(X_test)  

print(y_pred)

plt.figure(figsize=(150,150))
plt.plot(ys['Year'], ys['Global_Sales'])
plt.plot(ys['Year'], ys['y_pred'])
plt.title("Customer Sales using Random Forest")
plt.xlabel("Year")
plt.ylabel("Global Sales")
plt.legend(["Original Sales", "Predicted Sales"])
plt.show()