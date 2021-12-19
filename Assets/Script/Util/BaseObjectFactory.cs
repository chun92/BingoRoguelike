using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseObjectFactoryImpl<T, R> 
    where T : BaseObject, new()
    where R : RawData
{
    private const string DEFAULT_METAFILE_PATH = "Metafile/";
    private const string DEFAULT_IMAGE_PATH = "Images/";
    private string typeString = null;

    public static Dictionary<int, T> idDictionary;
    public static Dictionary<string, T> nameDictionary;

    public BaseObjectFactoryImpl()
    {
        typeString = typeof(T).Name;
    }

    public T get(int id)
    {
        if (idDictionary == null)
        {
            idDictionary = new Dictionary<int, T>();
        }
        
        if (idDictionary.ContainsKey(id))
        {
            return idDictionary[id];
        } else
        {
            return null;
        }
    }

    public T get(string name)
    {
        if (nameDictionary == null)
        {
            nameDictionary = new Dictionary<string, T>();
        }
        if (nameDictionary.ContainsKey(name))
        {
            return nameDictionary[name];
        } else
        {
            return null;
        }
    }

    public void loadAll()
    {
        try
        {
            TextAsset[] data = Resources.LoadAll<TextAsset>(DEFAULT_METAFILE_PATH + typeString + "/");
            if (data == null)
            {
                throw new Exception(typeString + " meta file load failed: " + DEFAULT_METAFILE_PATH + typeString + "/");
            }
            foreach (TextAsset t in data)
            {
                T obj = readFromMetafile(t);
                if (idDictionary == null)
                {
                    idDictionary = new Dictionary<int, T>();
                }
                if (idDictionary.ContainsKey(obj.id)) 
                {
                    throw new Exception(typeString + " id[" + obj.id + "] is duplicated: " + obj.name);
                } else
                {
                    idDictionary.Add(obj.id, obj);
                }

                        
                if (nameDictionary == null)
                {
                    nameDictionary = new Dictionary<string, T>();
                }
                if (nameDictionary.ContainsKey(obj.name)) 
                {
                    throw new Exception(typeString + " Name[" + obj.name + "] is duplicated: " + obj.id);
                } else
                {
                    nameDictionary.Add(obj.name, obj);
                }
            }
        } catch (Exception e)
        {
            Debug.LogError(e.ToString());
        }
    }

    private T readFromMetafile(TextAsset data)
    {
        try
        {
            R rawData = JsonUtility.FromJson<R>(data.ToString());
            T t = read(rawData);
            return t;
        } catch (Exception e)
        {
            Debug.LogError(e.ToString());
            return null;
        }
    }

    virtual protected T read(R rawData)
    {
        try
        {
            string name = rawData.name;
            int id = rawData.id;

            string imagePath = DEFAULT_IMAGE_PATH  + typeof(T).Name + "/" + rawData.image;
            Sprite image = Resources.Load<Sprite>(imagePath);
            if (image == null)
            {
                throw new Exception(typeString + " image load failed: " + imagePath);
            }

            T t = new T();
            t.setBaseObject(id, name, image);
            return t;
        } catch (Exception e)
        {
            Debug.LogError(e.ToString());
            return null;
        }
    }
}
