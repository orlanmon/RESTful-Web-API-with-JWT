using Newtonsoft.Json;
using RESTfulAPIJWT.Models;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json.Serialization;

namespace WinFormsTestApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        public async void button_Invoke_Click(object sender, EventArgs e)
        {


            ProductItem productItem = null;
            string sURL = string.Empty;
            string urlParameters = string.Empty;
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            List<ProductItem> products = new List<ProductItem>();

            using (HttpClient client = new HttpClient())
            {

                sURL = "http://localhost:8042/api/Product/GetProduct";

                client.BaseAddress = new Uri(sURL);
                urlParameters = "?SerialNumber=12345";

                // Add Accepted response content type
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                // Add JWT To Header 
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.textBox_JSONTOKEN.Text);

                HttpResponseMessage response = await client.GetAsync(urlParameters);

                if (response.IsSuccessStatusCode)
                {
                    productItem = await response.Content.ReadFromJsonAsync<ProductItem>();


                    products.Add(productItem);

                    this.dataGridView_Products.DataSource = products;
                    

                }
                else
                {


                    MessageBox.Show(response.StatusCode.ToString(), "Web API Response", buttons, MessageBoxIcon.Error);


                }

            }
        }

        private async void button_Invoke_Two_Click(object sender, EventArgs e)
        {

            string sURL = string.Empty;
            IAsyncEnumerable<ProductItem> productItems = null;
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            List<ProductItem> products = new List<ProductItem>();



            using (HttpClient client = new HttpClient())
            {

                sURL = "http://localhost:8042/api/Product/GetAllProducts";

                // Add Accepted response content type
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                // Add JWT To Header 
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.textBox_JSONTOKEN.Text);


                HttpResponseMessage response = await client.GetAsync(sURL);

                if (response.IsSuccessStatusCode)
                {
                    productItems = response.Content.ReadFromJsonAsAsyncEnumerable<ProductItem>()!;

                    if (productItems is not null)
                    {

                        await foreach (ProductItem product in productItems)
                        {
                            products.Add(product);
                        }

                        this.dataGridView_Products.DataSource = products;

                    }

                }
                else
                {
                    MessageBox.Show(response.StatusCode.ToString(), "Web API Response", buttons, MessageBoxIcon.Error);
                }
            }

        }

        private async void button_invoke_register_Click(object sender, EventArgs e)
        {

            UserDTO userDTO = new UserDTO();
            User user = null;
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            using (HttpClient client = new HttpClient())
            {

                userDTO.Username = this.textBox_register_username.Text;
                userDTO.Password = this.textBox_register_password.Text;

                // Setting Base address.
                // client.BaseAddress = new Uri("http://localhost:8042");


                // Add Accepted response content type
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Initialization of HttpResponseMessage.
                HttpResponseMessage response = new HttpResponseMessage();

                // HTTP POST
                response = await client.PostAsJsonAsync("http://localhost:8042/api/Auth/register", userDTO).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    // Reading Response.
                    string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    user = JsonConvert.DeserializeObject<User>(result)!;


                    if (!InvokeRequired)
                    {

                        this.textBox_login_username.Text = userDTO.Username;

                    }
                    else
                    {
                        Invoke(new Action(() =>
                        {
                            this.textBox_login_username.Text = userDTO.Username;
                        }));
                    }

                    if (!InvokeRequired)
                    {

                        this.textBox_login_password.Text = userDTO.Password;

                    }
                    else
                    {
                        Invoke(new Action(() =>
                        {
                            this.textBox_login_password.Text = userDTO.Password;
                        }));
                    }
                }
                else
                {
                    MessageBox.Show(response.StatusCode.ToString(), "Web API Response", buttons, MessageBoxIcon.Error);
                }

            }
        }

        private async void button_invoke_login_Click(object sender, EventArgs e)
        {
            UserDTO userDTO = new UserDTO();
            string JWT = string.Empty;
            MessageBoxButtons buttons = MessageBoxButtons.OK;


            using (HttpClient client = new HttpClient())
            {

                userDTO.Username = this.textBox_login_username.Text;
                userDTO.Password = this.textBox_login_password.Text;

                // Setting Base address.
                client.BaseAddress = new Uri("http://localhost:8042");

                // Add Accepted response content type
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

                // Initialization of HttpResponseMessage.
                HttpResponseMessage response = new HttpResponseMessage();

                // HTTP POST
                response = await client.PostAsJsonAsync("/api/Auth/Login", userDTO).ConfigureAwait(false);




                if (response.IsSuccessStatusCode)
                {
                    // Reading Response.
                    JWT = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    JWT = JsonConvert.DeserializeObject<string>(JWT);



                    if (!InvokeRequired)
                    {
                        this.textBox_JSONTOKEN.Text = JWT;
                    }
                    else
                    {
                        Invoke(new Action(() =>
                        {
                            this.textBox_JSONTOKEN.Text = JWT;
                        }));
                    }





                }
                else
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {

                        MessageBox.Show("Invalid Login", "Web API Response", buttons, MessageBoxIcon.Error);

                    }
                    else
                    {

                        MessageBox.Show(response.StatusCode.ToString(), "Web API Response", buttons, MessageBoxIcon.Error);

                    }


                }

            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label_JSONWebToken_Click(object sender, EventArgs e)
        {

        }
    }

}
